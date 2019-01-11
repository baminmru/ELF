<?php
	 class C_tplt_mask extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLT_MASK.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLT_MASK.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tplt_maskid' =>  $this->input->get_post('tplt_maskid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'ptype' =>   $this->input->get_post('ptype', TRUE)
                ,'sequence' =>   $this->input->get_post('sequence', TRUE)
                ,'pname' =>   $this->input->get_post('pname', TRUE)
                ,'paramformat' =>   $this->input->get_post('paramformat', TRUE)
                ,'colwidth' =>   $this->input->get_post('colwidth', TRUE)
                ,'phide' =>   $this->input->get_post('phide', TRUE)
            );
            $tplt_mask = $this->m_tplt_mask->setRow($data);
            print json_encode($tplt_mask);
    }
    function newRow() {
            log_message('debug', 'TPLT_MASK.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tplt_maskid' =>  $this->input->get_post('tplt_maskid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'ptype' =>   $this->input->get_post('ptype', TRUE)
                ,'sequence' =>   $this->input->get_post('sequence', TRUE)
                ,'pname' =>   $this->input->get_post('pname', TRUE)
                ,'paramformat' =>   $this->input->get_post('paramformat', TRUE)
                ,'colwidth' =>   $this->input->get_post('colwidth', TRUE)
                ,'phide' =>   $this->input->get_post('phide', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tplt_mask= $this->m_tplt_mask->newRow($instanceid,$data);
            $return = $tplt_mask;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLT_MASK.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tplt_mask = $this->m_tplt_mask->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tplt_mask
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
            	$sort[] = array('property'=>'ptype', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tplt_mask= $this->m_tplt_mask->getRowsByInstance($instanceid,$sort);
                }else{
                    $tplt_mask= $this->m_tplt_mask->getRows($sort);
                }
            }else{
              $tplt_mask= $this->m_tplt_mask->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplt_mask
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLT_MASK.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'ptype', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tplt_mask= $this->m_tplt_mask->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplt_mask
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
        log_message('debug', 'TPLT_MASK.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'ptype', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tplt_mask= $this->m_tplt_mask->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tplt_mask
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
        log_message('debug', 'TPLT_MASK.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tplt_maskid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tplt_mask->deleteRow($tempId);
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
        $this->load->model('M_tplt_mask', 'm_tplt_mask');
    }
}
?>