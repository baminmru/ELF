<?php
	 class C_tpu_views extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPU_VIEWS.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPU_VIEWS.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpu_viewsid' =>  $this->input->get_post('tpu_viewsid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'parentid' =>  $this->input->get_post('parentid', TRUE)
                ,'theformat' =>   $this->input->get_post('theformat', TRUE)
                ,'param' =>   $this->input->get_post('param', TRUE)
                ,'sequence' =>   $this->input->get_post('sequence', TRUE)
                ,'thewidth' =>   $this->input->get_post('thewidth', TRUE)
                ,'hideparam' =>   $this->input->get_post('hideparam', TRUE)
            );
            $tpu_views = $this->m_tpu_views->setRow($data);
            print json_encode($tpu_views);
    }
    function newRow() {
            log_message('debug', 'TPU_VIEWS.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpu_viewsid' =>  $this->input->get_post('tpu_viewsid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'parentid' =>  $this->input->get_post('parentid', TRUE)
                ,'theformat' =>   $this->input->get_post('theformat', TRUE)
                ,'param' =>   $this->input->get_post('param', TRUE)
                ,'sequence' =>   $this->input->get_post('sequence', TRUE)
                ,'thewidth' =>   $this->input->get_post('thewidth', TRUE)
                ,'hideparam' =>   $this->input->get_post('hideparam', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
                $parentid =  $this->input->get_post('parentid', TRUE);
            $tpu_views= $this->m_tpu_views->newRow($instanceid,$parentid,$data);
            $return = $tpu_views;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPU_VIEWS.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpu_views = $this->m_tpu_views->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpu_views
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'param', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $parentid=$this->input->get('parentid', FALSE);
            if(isset($parentid)){
                if($parentid!=''){
                    $tpu_views= $this->m_tpu_views->getRowsByParent($parentid,$sort);
                }else{
                    $tpu_views= $this->m_tpu_views->getRows($sort);
                }
            }else{
              $tpu_views= $this->m_tpu_views->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpu_views
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPU_VIEWS.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'param', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpu_views= $this->m_tpu_views->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpu_views
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'TPU_VIEWS.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'param', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpu_views= $this->m_tpu_views->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpu_views
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'TPU_VIEWS.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpu_viewsid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpu_views->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_tpu_views', 'm_tpu_views');
    }
}
?>