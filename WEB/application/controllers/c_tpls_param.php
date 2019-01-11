<?php
	 class C_tpls_param extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLS_PARAM.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLS_PARAM.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpls_paramid' =>  $this->input->get_post('tpls_paramid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'archtype' =>   $this->input->get_post('archtype', TRUE)
                ,'param' =>   $this->input->get_post('param', TRUE)
                ,'pos_left' =>   $this->input->get_post('pos_left', TRUE)
                ,'pos_top' =>   $this->input->get_post('pos_top', TRUE)
                ,'hideparam' =>   $this->input->get_post('hideparam', TRUE)
                ,'hideonschema' =>   $this->input->get_post('hideonschema', TRUE)
            );
            $tpls_param = $this->m_tpls_param->setRow($data);
            print json_encode($tpls_param);
    }
    function newRow() {
            log_message('debug', 'TPLS_PARAM.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpls_paramid' =>  $this->input->get_post('tpls_paramid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'archtype' =>   $this->input->get_post('archtype', TRUE)
                ,'param' =>   $this->input->get_post('param', TRUE)
                ,'pos_left' =>   $this->input->get_post('pos_left', TRUE)
                ,'pos_top' =>   $this->input->get_post('pos_top', TRUE)
                ,'hideparam' =>   $this->input->get_post('hideparam', TRUE)
                ,'hideonschema' =>   $this->input->get_post('hideonschema', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpls_param= $this->m_tpls_param->newRow($instanceid,$data);
            $return = $tpls_param;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLS_PARAM.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpls_param = $this->m_tpls_param->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpls_param
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
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpls_param= $this->m_tpls_param->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpls_param= $this->m_tpls_param->getRows($sort);
                }
            }else{
              $tpls_param= $this->m_tpls_param->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpls_param
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLS_PARAM.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
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
            $tpls_param= $this->m_tpls_param->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpls_param
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
        log_message('debug', 'TPLS_PARAM.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
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
            $tpls_param= $this->m_tpls_param->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpls_param
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
        log_message('debug', 'TPLS_PARAM.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpls_paramid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpls_param->deleteRow($tempId);
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
        $this->load->model('M_tpls_param', 'm_tpls_param');
    }
}
?>